import { Component, OnInit, Input } from '@angular/core';
import { Photo } from 'src/app/_models/photo';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})
export class PhotoEditorComponent implements OnInit {
  @Input() photos: Photo[];
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.initializeUploader();
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/' + this.authService.decodedToken.nameid + '/photos',  // the url
      authToken: 'Bearer ' + localStorage.getItem('token'), // Auth token
      isHTML5: true,  // Is HTML5
      allowedFileType:  ['image'],  // Only allow images
      removeAfterUpload: true,  // Remove the file from upload queue after uploaded
      autoUpload: false,  // We want the user to click a button when they want to upload the file.
      maxFileSize: 10 * 1024 * 1024 // Max file size 10mb
    });
    // Tell the uploader that we are not sending files with credentials. Needed to solve a browser bug.
    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        // Convert into an object
        const res: Photo = JSON.parse(response);
        // Building a photo object from the response from the server
        const photo = {
          id: res.id,
          url: res.url,
          dateAdded: res.dateAdded,
          description: res.description,
          isMain: res.isMain
        };
        // Push the new object / photo into the photos array
        this.photos.push(photo);
      }
    };
  }

}
