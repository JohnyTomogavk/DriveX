import { Routes } from '@angular/router';
import { HomePageComponent } from '../pages/home-page/home-page.component';
import { LoginPageComponent } from '../pages/login-page/login-page.component';
import { AppNavigationLayoutComponent } from '../pages/app-navigation-layout/app-navigation-layout.component';
import { SignUpPageComponent } from '../pages/sign-up-page/sign-up-page.component';

export const routes: Routes = [
  {
    path: '',
    component: AppNavigationLayoutComponent,
    children: [
      {
        path: 'home',
        component: HomePageComponent
      },
    ]
  },
  {
    path: 'sign-in',
    component: LoginPageComponent
  },
  {
    path: 'sign-up',
    component: SignUpPageComponent
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];
