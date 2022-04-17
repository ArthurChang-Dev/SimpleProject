import { useEffect } from 'react';

export const fetchTodoList = (setResult) => {
    useEffect(() => {
        fetch('https://jsonplaceholder.typicode.com/todos')
        .then(res => res.json())
        .then(result => setResult(result))
        .catch(err => console.log(err));
    }, [])
};

