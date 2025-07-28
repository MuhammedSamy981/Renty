import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProductDto } from "../types/product/ProductDto";
import { ProductUpdateDto } from "../types/product/ProductUpdateDto";
import { ProductAddDto } from "../types/product/ProductAddDto";
import { ProductDetailDto } from "../types/product/ProductDetailDto";
import { Filters } from "../types/Filters";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  

  constructor(private http:HttpClient) 
  {}

private apiUrl = "http://localhost:5214/odata/Products";
    public getAll():Observable<ProductDto[]>
    {

      // return this.http.get<ValueDto>(
//this.apiUrl+"?$expand=Images&$expand=Ratings");
     return this.http.get<ProductDto[]>(this.apiUrl);

    }
    
    public getAllFiltered(filters:Filters):Observable<ProductDto[]>
    {
          let params = new HttpParams();
   
    if(filters.productName!="undefined")
      {
 params= params.append('ProductName', filters.productName);  
}
  if(filters.categoryId!=0 ){

 params= params.append('CategoryId', filters.categoryId);
}
  if(filters.areaId!=0){ 

 params= params.append('AreaId',filters.areaId);
}

      return this.http.get<ProductDto[]>
      (this.apiUrl+"/filters",{params});
    }

    public getAllByUserId(id:string):Observable<ProductDto[]>
    {
      return this.http.get<ProductDto[]>
      (this.apiUrl+"/User/"+id);
    }
  
    public getAllByName(name:string):Observable<ProductDto[]>
    {
      return this.http.get<ProductDto[]>
      (this.apiUrl+name);
    }

    public getById(id:number,userId:string):Observable<ProductDetailDto>
    {
      return this.http.get<ProductDetailDto>(this.apiUrl+"/"+id+","+userId);
    }
  
    public add(product:ProductAddDto):Observable<object>
    {
      return this.http.post(this.apiUrl,product);
    }
  
    public update(product:ProductUpdateDto):Observable<object>
    {
      return this.http.put(this.apiUrl,product);
    }
  
    public delete(id:number):Observable<object>
    {
      return this.http.delete(this.apiUrl+"/"+id); 
    }

  public approve(id:number,status:string):Observable<object>
  {
    return this.http.put(this.apiUrl+"/"+id+","+status,null); 
  }
  
}
