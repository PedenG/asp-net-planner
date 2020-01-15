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

  private listeVille;
  private url = "https://geo.api.gouv.fr/";
  private codePostal = "";
  private ville = "";
  private titre = "";
  private description = "";
  private adresse = "";
  private tag = "";
  private json;
  private dateEvent = moment().format('YYYY-MM-DD');
  constructor(private http: HttpClient, public loginService:LoginService) {
    
   }

  ngOnInit() {
  }

  private search(){
    this.http.get(this.url + "communes?codePostal=" + this.codePostal).subscribe( data => {
      this.listeVille = data;
      this.ville = this.listeVille[0].nom;
    });
   
  }

  private addData(){
    this.json = {
      "Organisateur" : 0,
      "Titre" : this.titre,
      "Description" : this.description,
      "DateHeureCreation" : moment().format('YYYY-MM-DD'),
      "DateHeureEvenement" : this.dateEvent,
      "Ville": this.ville,
      "Cp" : this.codePostal,
      "Adresse" : this.adresse,
      "Tags" : this.tag
    }
    this.http.post("http://localhost:51764/api/Events/add", this.json).subscribe(data =>{
      console.log(data);
    });
  }

}
