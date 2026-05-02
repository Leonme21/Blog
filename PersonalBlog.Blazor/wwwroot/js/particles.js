window.particles = {
    init: function () {
        const canvas = document.getElementById('particleCanvas');
        if (!canvas) return;

        if (canvas._particlesAnim) {
            cancelAnimationFrame(canvas._particlesAnim);
        }

        const ctx = canvas.getContext('2d');
        let particles = [];
        let mouse = { x: null, y: null };

        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        function resize() {
            canvas.width = window.innerWidth;
            canvas.height = window.innerHeight;
            init();
        }

        window.removeEventListener('resize', canvas._resizeHandler);
        canvas._resizeHandler = resize;
        window.addEventListener('resize', resize);

        document.addEventListener('mousemove', canvas._mouseHandler = function (e) {
            mouse.x = e.clientX;
            mouse.y = e.clientY;
        });

        class Particle {
            constructor() {
                this.x = Math.random() * canvas.width;
                this.y = Math.random() * canvas.height;
                this.size = Math.random() * 2 + 0.5;
                this.speedX = (Math.random() - 0.5) * 0.5;
                this.speedY = (Math.random() - 0.5) * 0.5;
                this.opacity = Math.random() * 0.5 + 0.2;
            }

            update() {
                this.x += this.speedX;
                this.y += this.speedY;

                if (mouse.x !== null) {
                    const dx = mouse.x - this.x;
                    const dy = mouse.y - this.y;
                    const dist = Math.sqrt(dx * dx + dy * dy);
                    if (dist < 150) {
                        this.x -= dx * 0.01;
                        this.y -= dy * 0.01;
                    }
                }

                if (this.x < 0) this.x = canvas.width;
                if (this.x > canvas.width) this.x = 0;
                if (this.y < 0) this.y = canvas.height;
                if (this.y > canvas.height) this.y = 0;
            }

            draw() {
                ctx.fillStyle = 'rgba(255, 255, 255, ' + this.opacity + ')';
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
                ctx.fill();
            }
        }

        function init() {
            const count = Math.min(100, Math.floor(canvas.width * canvas.height / 15000));
            particles = [];
            for (let i = 0; i < count; i++) {
                particles.push(new Particle());
            }
        }

        function connectParticles() {
            for (let i = 0; i < particles.length; i++) {
                for (let j = i + 1; j < particles.length; j++) {
                    const dx = particles[i].x - particles[j].x;
                    const dy = particles[i].y - particles[j].y;
                    const dist = Math.sqrt(dx * dx + dy * dy);
                    if (dist < 120) {
                        const opacity = (1 - dist / 120) * 0.15;
                        ctx.strokeStyle = 'rgba(255, 255, 255, ' + opacity + ')';
                        ctx.lineWidth = 0.5;
                        ctx.beginPath();
                        ctx.moveTo(particles[i].x, particles[i].y);
                        ctx.lineTo(particles[j].x, particles[j].y);
                        ctx.stroke();
                    }
                }
            }
        }

        function animate() {
            if (!document.body.contains(canvas)) {
                if (canvas._particlesAnim) {
                    cancelAnimationFrame(canvas._particlesAnim);
                }
                return;
            }

            ctx.clearRect(0, 0, canvas.width, canvas.height);
            particles.forEach(function (p) {
                p.update();
                p.draw();
            });
            connectParticles();
            canvas._particlesAnim = requestAnimationFrame(animate);
        }

        init();
        animate();
    }
};