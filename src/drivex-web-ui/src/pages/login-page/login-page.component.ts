import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { Checkbox } from 'primeng/checkbox';
import { Divider } from 'primeng/divider';
import { RouterLink } from '@angular/router';
import { NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-login-page',
  imports: [
    AppPrimeNgModule,
    Checkbox,
    Divider,
    RouterLink,
    NgOptimizedImage
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPageComponent {
}
