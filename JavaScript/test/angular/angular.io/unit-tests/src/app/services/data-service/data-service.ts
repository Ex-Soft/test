import { Injectable } from '@angular/core';

import { IData } from "../../components/components.type";
import { IDataService } from "../services.type";


@Injectable({ providedIn: 'root' })
export class DataService implements IDataService {
    data?: IData;
}
