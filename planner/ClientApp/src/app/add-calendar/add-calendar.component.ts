import { Addcalander } from './../../model/model.add-calander';
import { AddCalandarService } from './../service/add-calandar.service';
import { Organisateur } from './../../model/model.organisateur';
import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import moment = require('moment');
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-add-calendar',
  templateUrl: './add-calendar.component.html',
  styleUrls: ['./add-calendar.component.css']
})
export class AddCalendarComponent implements OnInit {
  organisateur: Organisateur = new Organisateur();
  addCalandar:Addcalander=new Addcalander();
  private listeVille;
  private url = "https://geo.api.gouv.fr/";
  

  constructor(private http: HttpClient, public loginService: LoginService, private addCalandarService:AddCalandarService) {

  }

  ngOnInit() {
    this.loginService.loadUser();   
    this.addCalandar.OrganisateurIdOrga=this.loginService.userAuthentificated.id;
  }

  private search() {
    this.http.get(this.url + "communes?codePostal=" + this.addCalandar.cp).subscribe(data => {
      this.listeVille = data;
      this.addCalandar.ville = this.listeVille[0].nom;
    });

  }

  private addData() {
   this.addCalandarService.insertCalander( this.addCalandar)
    .subscribe(data=>{
      console.log(data);
    }, err=>{
      console.log(err);
    })
  }
  

}
