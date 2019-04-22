import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class ToastNotificationService {
	public showAlert$: EventEmitter<Alert>;

	constructor() {
		this.showAlert$ = new EventEmitter();
	}

	showError(message: string) {
		const alert: Alert = {
			type: 'danger',
			message: message,
		};
		this.showAlert$.emit(alert);
	}
}
