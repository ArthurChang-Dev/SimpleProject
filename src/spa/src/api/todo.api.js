import { useEffect } from 'react';

// export const fetchTodoDemo = (setResult) => {
//     useEffect(() => {
//         fetch('https://jsonplaceholder.typicode.com/todos')
//         .then(res => res.json())
//         .then(result => setResult(result))
//         .catch(err => console.log(err));
//     }, []);
// };

export const fetchTodoList = (updated, setResult) => {
    useEffect(() => {
        console.log("calling useeffect.");
        fetch('/api/todo')
        .then(res => res.json())
        .then(result => {
            setResult(result.todos);
        })
    .catch(err => console.log(err));
    }, [updated]);
}

export const createTodo = (todo, updated, setUpdated) => {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: todo })
    };
    fetch('/api/todo/create', requestOptions)
        .then(res => {
            console.log('save data successfully.');
            setUpdated(updated + 1);
        })
        .catch(err => {
            alert('error happended');
            console.log(err);
        } );
}

export const deleteTodo = (id, updated, setUpdated) => {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    };
    fetch('/api/todo/delete/' + id, requestOptions)
    .then( res => {
        console.log('delete todo successfully. ');
        setUpdated(updated + 1);
    })
    .catch(err => {
        alert('error happend when delete');
        console.log(err);
    })
}