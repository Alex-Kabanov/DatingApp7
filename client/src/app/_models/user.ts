export interface User {
    username: string;
    token: string;
}

interface Car {
    color: string,
    model: string,
    topSpeed?: number;
}

const car2: Car = {
    color: 'blue',
    model: 'BMW'
}