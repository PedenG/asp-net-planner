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
  constructor(private http: HttpClient) {
    
   }

  ngOnInit() {
  }

  private search(){
    this.http.get(this.url + "communes?codePostal=" + this.codePostal).subscribe( data => {
      this.listeVille = data;
      this.ville = this.listeVille[0].nom;
    });
   
  }

}
