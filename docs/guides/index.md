---
title: Documentation
permalink: /guides/
---

This section reorganizes the original repository articles under a single landing page.

## HealthChecks UI

- [UI Docker image]({{ '/ui-docker.html' | relative_url }})
- [Webhooks and failure notifications]({{ '/webhooks.html' | relative_url }})
- [Interface styling and branding]({{ '/styles-branding.html' | relative_url }})
- [UI changelog]({{ '/ui-changelog.html' | relative_url }})

## Kubernetes

- [Kubernetes operator]({{ '/k8s-operator.html' | relative_url }})
- [Automatic Kubernetes service discovery]({{ '/k8s-ui-discovery.html' | relative_url }})
- [Liveness and readiness probes]({{ '/kubernetes-liveness.html' | relative_url }})

## Recommended reading order

1. Start with the Docker or branding guide if you are wiring the UI into an existing service.
2. Move to the webhook guide when you need alerting integrations such as Teams or Azure Functions.
3. Use the Kubernetes articles when you need discovery, probes, or operator-based deployment.
