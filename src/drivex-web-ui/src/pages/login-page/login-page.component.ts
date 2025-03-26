import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { Divider } from 'primeng/divider';
import { RouterLink } from '@angular/router';
import { NgOptimizedImage } from '@angular/common';
import { RoutingConstants } from "../../constants/routing.constants";

@Component({
  selector: 'app-login-page',
  imports: [
    AppPrimeNgModule,
    Divider,
    RouterLink,
    NgOptimizedImage
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
    protected readonly RoutingConstants = RoutingConstants;
}
