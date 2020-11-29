addEventListener('message', ({ data }) => {
    console.log('foobar')
    const response = 'worker response to ${data}';
    postMessage(response);
});

