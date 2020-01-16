import { Organisateur } from "./model.organisateur"

 export class Addcalander {

    OrganisateurIdOrga: number=0;
    titre: String="";
    description: String="";
    dateHeureCreation: Date=new Date();
    dateHeureEvenement: Date=new Date();
    ville:String="";
    cp: String="";
    adresse:String="";
    tags:String="";
}