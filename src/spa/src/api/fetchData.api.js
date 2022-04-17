import { useEffect } from 'react';

// export const fetchTodoDemo = (setResult) => {
//     useEffect(() => {
//         fetch('https://jsonplaceholder.typicode.com/todos')
//         .then(res => res.json())
//         .then(result => setResult(result))
//         .catch(err => console.log(err));
//     }, []);
// };

export const fetchTodoList = (setResult) => {
    useEffect(() => {
        fetch('/api/todo')
    .then(res => res.json())
    .then(result => setResult(result.todos))
    .catch(err => console.log(err));
    }, []);
}
