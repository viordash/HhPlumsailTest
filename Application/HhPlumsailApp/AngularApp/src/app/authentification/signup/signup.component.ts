import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/services/http-client.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserModel } from '../userModel';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  formGroup: FormGroup;
  user: Observable<UserModel>;

  constructor(private httpClientService: HttpClientService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      userName: ['test', Validators.required],
      password: ['123456', [Validators.required, Validators.minLength(4)]],
      confirmPassword: ['123456', [Validators.required, Validators.minLength(4)]],
    });

  }

  submit() {
    const formValue = this.formGroup.value;
    // if (formValue.password !== formValue.confirmPassword) {
    //   this.formGroup.controls['password'].setErrors({'incorrect': true});
    //   this.formGroup.controls['confirmPassword'].setErrors({'incorrect': true});
    // }

    if (this.formGroup.valid) {
      const user: UserModel = {
        userName: formValue.userName,
        password: formValue.password,
        confirmPassword: formValue.confirmPassword
      }
      this.httpClientService.signUp(user)
        .subscribe(result => {
					this.router.navigate(['/'])
        });
    }
  }
}
