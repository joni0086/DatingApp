using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        /* Ordinary constructor
         *
         * Input:   (repo): The repository
         *          (mapper):
         *          (cloudinaryConfig): Contains the cloudinary config from services
         * Output:  None
         */
        public PhotosController(IDatingRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            // Create the cloudinary account
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            // Cloudinary instance that takes an account as input
            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name= "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);

            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId,
            [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            // Make sure the user id matches the token
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            // Get the user from the repo
            var userFromRepo = await _repo.GetUser(userId);
            // Store information about the file
            var file = photoForCreationDto.File;
            // Used to store the result from cloudinary
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    // Create the upload parameters
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        // Crop the image as a 500x500 image
                        Transformation = new Transformation()
                            .Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    // Upload the photo to cloudinary
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            // Update the DTO
            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;
            // Map the DTO into a photo
            var photo = _mapper.Map<Photo>(photoForCreationDto);
            // If it is the first photo, set it to main
            if (!userFromRepo.Photos.Any(u => u.IsMain))
            {
                photo.IsMain = true;
            }
            // Add the photo
            userFromRepo.Photos.Add(photo);
            // Save the photo
            if (await _repo.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { userId = userId, id = photo.Id}, photoToReturn);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int userId, int id)
        {
            // Make sure the user id matches the token
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            // Make sure that the user is trying to update their own photo
            var user = await _repo.GetUser(userId);
            // If the id does not match any id in the users collection
            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            // Get the photo from the repo
            var photoFromRepo = await _repo.GetPhoto(id);
            // Check if it already is the main photo
            if (photoFromRepo.IsMain)
            {
                return BadRequest("This is already the main photo");
            }
            // Get the current photo from the repo
            var currentMainPhoto = await _repo.GetMainPhotoForUser(userId);
            // Set the current photo to not main, and the new one to main
            currentMainPhoto.IsMain = false;
            photoFromRepo.IsMain = true;
            // Save changes
            if (await _repo.SaveAll()) {
                return NoContent();
            }
            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int userId, int id)
        {
            // Make sure the user id matches the token
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            // Make sure that the user is trying to update their own photo
            var user = await _repo.GetUser(userId);
            // If the id does not match any id in the users collection
            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }
            // Get the photo from the repo
            var photoFromRepo = await _repo.GetPhoto(id);
            // Check if it already is the main photo
            if (photoFromRepo.IsMain)
            {
                return BadRequest("You cannot delete your main photo");
            }
            // Make sure that the image that should be deleted can be deleted, and is stored in cloudinary with a public id
            if (photoFromRepo.PublicId != null)
            {
                // Delete parameters to give cloudinary
                var deleteParams = new DeletionParams(photoFromRepo.PublicId);
                // Response we get back from cloudinary
                var result = _cloudinary.Destroy(deleteParams);
                // If we deleted the image successfully from cloud, then delete the reference from the database
                if (result.Result == "ok")
                {
                    _repo.Delete(photoFromRepo);
                }
            }
            // If the photo is null, then just delete it
            if (photoFromRepo.PublicId == null)
            {
                _repo.Delete(photoFromRepo);
            }
            // Return Ok if everything went well
            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Failed to delete the photo");
        }

    }
}