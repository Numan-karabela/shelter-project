import { list_Animal_image } from "./list_animal_image";

export class list_Animal{
    id:string;
    name:string;
    age:number;
    gender:string;
    type:string;
    vaccination:string;
    animalImageFiles?:list_Animal_image[];
    imagePath:string;

}