import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-calendar',
  templateUrl: './list-calendar.component.html',
  styleUrls: ['./list-calendar.component.css']
})
export class ListCalendarComponent implements OnInit {
i:number=0;
  public listeEvent;
  constructor(private http : HttpClient, public loginService:LoginService) { 
    this.i=this.loginService.userAuthentificated.id
  }

  ngOnInit() {
    this.getEvents();
    this.loginService.loadUser();
    
  }

  private getEvents(){
    this.http.get("https://localhost:16550/API/Orgas/"+this.i+"/events").subscribe( data => {
      this.listeEvent = data;
      console.log(this.listeEvent);
    });
  }
 

}
