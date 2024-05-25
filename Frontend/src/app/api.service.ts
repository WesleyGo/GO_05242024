import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:16001'; 

  private apiKey = 'my-api-key'; // For brevity, this should not be hardcoded here and must be store securely
  private headers = new HttpHeaders({
    "X-API-KEY": this.apiKey
  });
  constructor(private http: HttpClient) {}

  getAllItems(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/items`, { headers: this.headers })
  }

  getItemById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/items/${id}`, { headers: this.headers });
  }

  createItem(item: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/items`, item, { headers: this.headers });
  }

  updateItem(id: number, item: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/api/items/${id}`, item, { headers: this.headers });
  }
}
