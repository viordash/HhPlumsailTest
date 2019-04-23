import { Injectable } from '@angular/core';
import { ToastNotificationService } from './toast-notification.service';

@Injectable({
	providedIn: 'root'
})
export class ErrorHandlerService {
	constructor(public snotify: ToastNotificationService) { }

	private tryParseErroObject(errorObj: any): string {
		if (typeof errorObj === "string") {
			return errorObj;
		}
		let message = '';
		for (var prop in errorObj) {
			if (errorObj.hasOwnProperty(prop)) {
				message += errorObj[prop] + ". ";
			}
		}
		return message;
	}

	private tryParseError(error: any): any {
		try {
			if (!!error.error && !!error.error.message) {
				return error.error.message;
			} else  if (!!error.error && !!error.error.error) {
				return this.tryParseErroObject(error.error.error);
			} else if (!!error.message) {
				return error.message;
			}
			return error;
		} catch (ex) {
			return error.toString();
		}
	}

	show(error: any): void {
		const parsedError = this.tryParseError(error);
		this.snotify.showError(parsedError);
	}
}