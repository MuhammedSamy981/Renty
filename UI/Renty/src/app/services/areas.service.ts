import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AreaDto } from '../types/area/AreaDto';
import { AreaAddDto } from '../types/area/AreaAddDto';
import { AreaUpdateDto } from '../types/area/AreaUpdateDto';

@Injectable({
  providedIn: 'root'
})

export class AreasService {

private apiUrl = "http://localhost:5214/odata/Areas";
  constructor(private http:HttpClient) 
  { }

  public getAll():Observable<AreaDto[]>
  {
    return this.http.get<AreaDto[]>(this.apiUrl);
  }

  public getAllByCityId(id:number):Observable<AreaDto[]>
  {
    return this.http.get<AreaDto[]>(this.apiUrl+"/City/"+id);
  }
  
  public getAllByCityName(name:string):Observable<AreaDto[]>
  {
    return this.http.get<AreaDto[]>(this.apiUrl+"/City"+name);
  }
  public getById(id:number):Observable<AreaDto>
  {
    return this.http.get<AreaDto>(this.apiUrl+"/"+id);
  }

  public add(area:AreaAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,area);
  }

  public update(area:AreaUpdateDto):Observable<object>
  {
    return this.http.put(this.apiUrl,area);
  }

  public delete(id:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+id); 
  }
  
}
