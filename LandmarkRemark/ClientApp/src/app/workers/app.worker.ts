addEventListener('message', ({ data }) => {
    console.log('foobar')
    const response = 'worker response to ${data}';
    data.postMessage(response);
});

