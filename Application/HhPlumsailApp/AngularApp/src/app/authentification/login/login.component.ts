import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserModel } from '../userModel';
import { HttpClientService } from 'src/app/services/http-client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formGroup: FormGroup;
  user: Observable<UserModel>;

  constructor(private httpClientService: HttpClientService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });

  }

  login() {
    if (this.formGroup.valid) {
      const formValue = this.formGroup.value;
      const user: UserModel = {
        userName: formValue.userName,
        password: formValue.password,
        confirmPassword: null
      }
      this.httpClientService.login(user);
    }
  }
}
