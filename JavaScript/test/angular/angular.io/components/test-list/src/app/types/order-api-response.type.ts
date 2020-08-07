export type OrderApiResponse = {
  id: number;
  date: string;
  items: [{
    id: number;
    name: string;
    price: number;
    count: number;
  }]
};
