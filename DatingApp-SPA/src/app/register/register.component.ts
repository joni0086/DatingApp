import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;

  constructor(private authService: AuthService, private alertify: AlertifyService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      // Gender
      gender: ['male'],
      // Username with required validator
      username: ['', Validators.required],
      // Known as with required validator
      knownAs: ['', Validators.required],
      // The birth date with required validator
      dateOfBirth: [null, Validators.required],
      // City with required validator
      city: ['', Validators.required],
      // Country with required validator
      country: ['', Validators.required],
      // Password required, and  min /max length
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      // Password confirm with required validator
      confirmPassword: ['', Validators.required]
      // (we use a custom validator to compare password with confirm password added to the formgroup)
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    // Return null if passwords match, else a mismatch object set to true
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  register() {
    /*
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('registration successful');
    }, error => {
      this.alertify.error(error);
    });
    */
    console.log(this.registerForm.value);
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
