import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

let _getBaseUrl : ()=> string;

if (environment.production) {
  enableProdMode();
  _getBaseUrl = () => document.getElementsByTagName('base')[0].href;
} else {
  _getBaseUrl = () => 'http://localhost:4716/';
}

const providers = [
  { provide: 'BASE_URL', useFactory: _getBaseUrl, deps: [] }
];

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.error(err));
