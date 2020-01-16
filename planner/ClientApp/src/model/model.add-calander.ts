import { Organisateur } from "./model.organisateur"

 export class Addcalander {

    organisateur: Organisateur=new Organisateur();
    titre: String="";
    description: String="";
    dateHeureCreation: Date=new Date();
    dateHeureEvenement: Date=new Date();
    ville:String="";
    cp: String="";
    adresse:String="";
    tags:String="";
}