// https://hackwild.com/article/event-handling-techniques/

class ClassWithEvent extends EventTarget {
    constructor() {
        super();
    }

    public start(): void {
        setTimeout(() => {
            this.dispatchEvent(
                new CustomEvent("completed", { detail: { date: new Date() }})
            );
        }, 1000);
    }
}

const classWithEvent = new ClassWithEvent();
classWithEvent.addEventListener("completed", handler1);
classWithEvent.addEventListener("completed", handler2);

function handler1(e) {
    if (window.console && console.log) {
        console.log("TestEvent handler1(%o)", e);
    }
}

function handler2(e) {
    if (window.console && console.log) {
        console.log("TestEvent handler2(%o)", e);
    }
}

classWithEvent.start();
