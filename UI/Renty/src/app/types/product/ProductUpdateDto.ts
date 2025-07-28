export interface ProductUpdateDto {
  id: number;
  name: string;
  categoryId: number;
  price: number;
  description: string;
  userId: string | null;
}