export interface ProductAddDto {
  name: string;
  categoryId: number;
  price: number;
  description: string;
  userId: string | null;
}