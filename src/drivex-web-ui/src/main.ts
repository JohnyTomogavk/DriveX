import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './config/app.config';
import { AppRootComponent } from './pages/app-root/app-root.component';

bootstrapApplication(AppRootComponent, appConfig)
  .catch((err) => console.error(err));
