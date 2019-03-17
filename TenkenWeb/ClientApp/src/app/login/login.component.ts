import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  model = new User('Thien', '123');
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  onSubmit() {
    this.http.post<boolean>(this.baseUrl + 'api/UserManager/Login', this.model).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
}
}

export class User {

  constructor(
    public name: string, 
    public password: string
  ) { }

}
