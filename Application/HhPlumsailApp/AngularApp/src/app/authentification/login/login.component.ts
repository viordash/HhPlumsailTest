import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UserModel } from '../userModel';
import { HttpClientService } from 'src/app/services/http-client.service';
import { NgbActiveModal, NgbTabset } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
	private tabs: NgbTabset;

	@ViewChild('tabs') public set _tabs(tabs: NgbTabset) {
		if (tabs) {
			this.tabs = tabs;
		}
	}

	@Input() returnUrl: string;

	activeIdString: string;
	formGroup: FormGroup;
	user: Observable<UserModel>;

	constructor(private httpClientService: HttpClientService, private formBuilder: FormBuilder,
		public activeModal: NgbActiveModal, private router: Router) { }

	ngOnInit() {
		this.formGroup = this.formBuilder.group({
			userName: ['', Validators.required],
			password: ['', Validators.required],
			confirmPassword: [],
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


	signup() {
		const formValue = this.formGroup.value;
		if (this.formGroup.valid) {
			const user: UserModel = {
				userName: formValue.userName,
				password: formValue.password,
				confirmPassword: formValue.confirmPassword
			}
			this.httpClientService.signUp(user)
				.subscribe(result => {
					this.tabs.select('login');
				});
		}
	}
}
