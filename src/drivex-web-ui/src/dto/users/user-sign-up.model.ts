export interface UserSignUpRequestDto {
  fullName: string;
  userName: string;
  password: string;
  confirmedPassword: string;
  email: string;
  phoneNumber: string | null;
}
