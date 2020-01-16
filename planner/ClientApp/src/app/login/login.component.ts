import { Router } from '@angular/router';
import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService:LoginService, private router:Router) { }

  ngOnInit() {
    
  }
  onLogin(dataForm:any){
    this.loginService.login(dataForm.username, dataForm.password);
     console.log(this.loginService.isAuthentificated);
    if(this.loginService.isAuthentificated==true){
      this.loginService.saveUser();
      this.router.navigateByUrl('/Calendar');
      console.log("succé");
    }
    
  }

}
