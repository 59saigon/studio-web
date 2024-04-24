import { BaseEntity } from "./BaseEntity";
import { City } from "./City";

export interface Country extends BaseEntity {
    countryName: string; // Corresponds to CountryName in C#
    cities?: City[]; 
}