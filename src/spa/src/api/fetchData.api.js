import { useEffect } from 'react';

export const fetchTodoList = (setResult) => {
    useEffect(() => {
        fetch('https://jsonplaceholder.typicode.com/todos')
        .then(res => res.json())
        .then(result => setResult(result))
        .catch(err => console.log(err));
    }, [])
};

export const fetchTodoTest = () => {
    fetch('/api/todo')
    .then(res => res)
    .catch(err => console.log(err));
}
