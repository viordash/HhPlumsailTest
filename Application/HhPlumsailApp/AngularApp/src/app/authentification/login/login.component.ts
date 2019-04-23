import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserModel } from '../userModel';
import { HttpClientService } from 'src/app/services/http-client.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Input() returnUrl: string;

  formGroup: FormGroup;
  user: Observable<UserModel>;

  constructor(private httpClientService: HttpClientService, private formBuilder: FormBuilder, public activeModal: NgbActiveModal) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
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
      this.httpClientService.login(user)
        .subscribe(result => {
          this.activeModal.close(true);
        });

    }
  }
}
