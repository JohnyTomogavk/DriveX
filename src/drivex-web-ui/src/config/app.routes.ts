import { Routes } from '@angular/router';
import { HomePageComponent } from '../pages/home-page/home-page.component';
import { LoginPageComponent } from '../pages/login-page/login-page.component';
import { AppNavigationLayoutComponent } from '../pages/app-navigation-layout/app-navigation-layout.component';
import { SignUpPageComponent } from '../pages/sign-up-page/sign-up-page.component';
import { RoutingConstants } from '../constants/routing.constants';

export const routes: Routes = [
  {
    path: '',
    component: AppNavigationLayoutComponent,
    children: [
      {
        path: RoutingConstants.HOME,
        component: HomePageComponent
      },
    ]
  },
  {
    path: RoutingConstants.SIGN_IN_ROUTE,
    component: LoginPageComponent
  },
  {
    path: RoutingConstants.SIGN_UP_ROUTE,
    component: SignUpPageComponent
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];
