import { Component } from '@angular/core';
import { AuthentificationService } from '../services/authentification.service';

@Component({
	selector: 'app-nav-menu',
	templateUrl: './nav-menu.component.html',
	styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
	isExpanded = false;
	public get welcomeText(): string {
		const username = this.authentification.getUserName();
		if (!!!username) {
			return null;
		}
		return 'Welcome ' + username + '!';
	}

	constructor(private authentification: AuthentificationService) {
	}

	collapse() {
		this.isExpanded = false;
	}

	toggle() {
		this.isExpanded = !this.isExpanded;
	}

	logout() {
		this.authentification.logout();
	}

}
