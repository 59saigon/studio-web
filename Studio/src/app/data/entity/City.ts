import { Guid } from "guid-typescript";
import { BaseEntity } from "./BaseEntity";
import { Country } from "./Country";

export interface City extends BaseEntity {
    cityName: string; // CityName in C#
    countryId: Guid; // Guid represented as string
    country?: Country; // Reference to Country class, optional
    locations?: Location[];
}
