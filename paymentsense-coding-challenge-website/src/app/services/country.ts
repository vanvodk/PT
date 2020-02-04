import { Currency } from './currency';
import { Language } from './Language';

export class Country {
  Alpha2Code: string;
  Name: string;
  Flag: string;
  CallingCodes: string[];
  Capital: string;
  Region: string;
  Population: number;
  Demonym: string;
  Timezones: string[];
  Currencies: Currency[];
  Languages: Language[];
  Borders: string[];
}
