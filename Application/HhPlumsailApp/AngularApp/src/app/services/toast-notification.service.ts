import { Injectable, EventEmitter } from '@angular/core';
import { AlertModel } from '../alertModel';


@Injectable({
	providedIn: 'root'
})
export class ToastNotificationService {
	public showAlert$: EventEmitter<AlertModel>;

	constructor() {
		this.showAlert$ = new EventEmitter();
	}

	showError(message: string) {
		const alert: AlertModel = {
			type: 'danger',
			message: message,
		};
		this.showAlert$.emit(alert);
	}
}
