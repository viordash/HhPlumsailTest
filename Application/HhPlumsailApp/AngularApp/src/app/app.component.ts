import { Component } from '@angular/core';
import { ToastNotificationService } from './services/toast-notification.service';


@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})

export class AppComponent {
	alert: AlertModel = null;

	title = 'A programming task for candidates for developer JavaScript, C#';


	constructor(snotify: ToastNotificationService) {
		snotify.showAlert$.subscribe(alert => this.showAlert(alert));
	}

	showAlert(alert: AlertModel) {
		this.alert = alert;
	}

	closeAlert() {
		this.alert = null;
	}
}
