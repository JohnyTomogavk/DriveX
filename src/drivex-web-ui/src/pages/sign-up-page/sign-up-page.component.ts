import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  signal,
  ViewEncapsulation
} from '@angular/core';
import { Button } from 'primeng/button';
import { InputText } from 'primeng/inputtext';
import { Router, RouterLink } from '@angular/router';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { InputMask } from 'primeng/inputmask';
import { NgOptimizedImage } from '@angular/common';
import { UserService } from '../../api/users/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { FormErrorPipe } from '../../pipes/form-error.pipe';
import { UserConstants } from '../../constants/user-account-up.constants';
import { passwordFormatValidator } from '../../validators/password-format.validator';
import { passwordsMatch } from '../../validators/passwords-match.validator';
import { userFullNameValidator } from '../../validators/user-fullname.validator';
import { usernameNameValidator } from '../../validators/username-format.validator';
import { HttpResponse, HttpStatusCode } from '@angular/common/http';
import { RoutingConstants } from '../../constants/routing.constants';

@Component({
  selector: 'app-sign-up-page',
  imports: [
    Button,
    InputText,
    RouterLink,
    AppPrimeNgModule,
    InputMask,
    NgOptimizedImage,
    TranslatePipe,
    FormErrorPipe
  ],
  providers: [UserService],
  templateUrl: './sign-up-page.component.html',
  styleUrl: './sign-up-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class SignUpPageComponent implements OnInit {
  public signUpForm!: FormGroup;
  public isLoading = signal(false);
  protected readonly userConstants = UserConstants;
  protected readonly RoutingConstants = RoutingConstants;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) {
  }

  ngOnInit(): void {
    this.signUpForm = this.formBuilder.group({
        fullName: [null, [Validators.required], [userFullNameValidator()]],
        userName: [null, [Validators.required, Validators.minLength(this.userConstants.MinLoginLength)], [usernameNameValidator()]],
        email: [null, [Validators.required, Validators.email]],
        password: [null, [Validators.required, Validators.minLength(this.userConstants.MinPasswordLength)], [passwordFormatValidator()]],
        confirmedPassword: [null, [Validators.required]],
        phoneNumber: [null]
      },
      {
        asyncValidators: [passwordsMatch('password', 'confirmedPassword')]
      })
  }

  public onSignUpClick(): void {
    if (this.signUpForm.invalid) {
      this.signUpForm.markAllAsTouched();

      return;
    }

    const formValue = this.signUpForm.value;
    this.isLoading.set(true);

    this.userService.signUp(formValue).subscribe({
      next: (response) => {
        if (response.status === HttpStatusCode.Created) {
          this.router.navigate([RoutingConstants.SIGN_IN_ROUTE]).then();
        }

        this.isLoading.set(false);
      },
      error: (response: HttpResponse<void>) => {
        console.log(response)
        if (response.status === HttpStatusCode.Conflict) {
          // TODO: Show user duplication error
        }

        this.isLoading.set(false);
      }
    });
  }
}
