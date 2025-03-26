import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';

export function userFullNameValidator(): ValidatorFn {
  const regex = new RegExp("^[А-ЯЁA-Z][а-яёa-z-]{1,49}(?:\\s[А-ЯЁA-Z][а-яёa-z-]{1,49}){2}$");

  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    const fullname = control?.value;

    if (!fullname || fullname.match(regex)) {
      return of(null);
    }

    return of({
      "INVALID_FULLNAME": true
    })
  };
}


