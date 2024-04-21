import { BaseResult } from "../base/BaseResult";
import { CityResult } from "./CityResult";

export interface CountryResult extends BaseResult{
    countryName: string;
    cities: CityResult[];
}