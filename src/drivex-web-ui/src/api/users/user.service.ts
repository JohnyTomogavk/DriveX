import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from "rxjs";
import { UserSignUpRequestDto } from "../../dto/users/user-sign-up.model";
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {
  }

  public signUp(userSignUpDto: UserSignUpRequestDto): Observable<HttpResponse<void>> {
    return this.httpClient.post<void>(`${environment.baseUrl}/users/sign-up`, userSignUpDto, {
      observe: 'response',
    });
  }
}

