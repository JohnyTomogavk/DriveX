import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable, of } from 'rxjs';

export function passwordFormatValidator(): AsyncValidatorFn {
  const passwordRegex = new RegExp("^(?=.*\\d)(?=.*[a-zA-Z])[a-zA-Z0-9]{6,}$");

  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    const passwordValue = control?.value;

    if (!passwordValue || passwordValue.match(passwordRegex)) {
      return of(null);
    }

    return of({
      "PASSWORD_INVALID_FORMAT": true
    })
  };
}
