export interface OrderModel {
    id: number;
    date: number;
    customer: string;
    status: object;
    prepaid: boolean;
    summ: number;
    description: string;
}
