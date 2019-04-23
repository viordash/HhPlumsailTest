import { Component } from '@angular/core';
import { ToastNotificationService } from './services/toast-notification.service';
import { NgbModalOptions, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './authentification/login/login.component';
import { ErrorHandlerService } from './services/error-handler.service';
import { Router } from '@angular/router';


@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})

export class AppComponent {
	alert: AlertModel = null;

	title = 'A programming task for candidates for developer JavaScript, C#';


	constructor(snotify: ToastNotificationService, private errorHandler: ErrorHandlerService, private modalService: NgbModal, private router: Router) {
		snotify.showAlert$.subscribe(alert => this.showAlert(alert));
		errorHandler.showLogin$.subscribe(url => this.openLogin(url));
	}

	showAlert(alert: AlertModel) {
		this.alert = alert;
	}

	closeAlert() {
		this.alert = null;
	}

	openLogin(returnUrl: string) {
		const config: NgbModalOptions = {
			backdrop: 'static',
			keyboard: false,
			size: 'sm'
		}
		const modalRef = this.modalService.open(LoginComponent, config);
		modalRef.componentInstance.returnUrl = returnUrl;
		modalRef.result.then((value) => {
			if (!!value) {
				if (this.router.url == returnUrl) {
					window.location.reload();
				} else {
					this.router.navigate([returnUrl]);
				}
			}
		});
	}
}
