import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';

export function usernameNameValidator(): ValidatorFn {
  const regex = new RegExp("^[a-zA-Z0-9._-]{3,}$");

  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    const username = control?.value;

    if (!username || username.match(regex)) {
      return of(null);
    }

    return of({
      "INVALID_USERNAME_FORMAT": true
    })
  };
}
