import { ChangeDetectionStrategy, Component, ViewEncapsulation } from '@angular/core';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { InputText } from 'primeng/inputtext';
import { RouterLink } from '@angular/router';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { InputMask } from 'primeng/inputmask';
import { NgOptimizedImage } from '@angular/common';

@Component({
  selector: 'app-sign-up-page',
  imports: [
    Button,
    Divider,
    InputText,
    RouterLink,
    AppPrimeNgModule,
    InputMask,
    NgOptimizedImage
  ],
  templateUrl: './sign-up-page.component.html',
  styleUrl: './sign-up-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class SignUpPageComponent {
}
