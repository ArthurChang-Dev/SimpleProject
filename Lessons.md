## React Map
- When try to iterate the result and create component, the map should use ( not {
    ```js
    //wrong
    //result.map(item => {})
    //correct
    result.map(item => ())
    ```